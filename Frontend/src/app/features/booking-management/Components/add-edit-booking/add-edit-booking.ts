import { JsonPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { disabled } from '@angular/forms/signals';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-edit-booking',
  imports: [ReactiveFormsModule],
  templateUrl: './add-edit-booking.html',
  styleUrl: './add-edit-booking.scss',
})
export class AddEditBooking {
  bookingForm!: FormGroup;
  typeOptions = ['Inbound', 'Outbound', 'Both'];
  private fd = inject(FormBuilder);
  private activatedRoute = inject(ActivatedRoute);
  editMode: boolean = false;
  private Route = inject(Router);
  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      const dockId = params['id'];
      if (dockId) {
        this.editMode = true;
      }
    });

    this.bookingForm = this.fd.group({
      generatedReferenceNumber: [`BK-${Date.now()}`, { disabled: true }],
      dock: [null, [Validators.required, Validators.maxLength(100)]],
      companyName: [null, [Validators.required, Validators.maxLength(100)]],
      licensePlate: [null, [Validators.required, Validators.maxLength(100)]],
      direction: [null, [Validators.required]],
      startTime: [
        null,
        [Validators.required, Validators.pattern('^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$')],
      ],
      endTime: [
        null,
        [Validators.required, Validators.pattern('^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$')],
      ],
    });

    this.bookingForm.get('startTime')?.valueChanges.subscribe((startTime) => {
      const endTimeControl = this.bookingForm.get('endTime');

      if (startTime?.value && endTimeControl?.value) {
        this.checkTimeValidation();
      }
    });

    this.bookingForm.get('endTime')?.valueChanges.subscribe((endTime) => {
      const startTimeControl = this.bookingForm.get('startTime');

      if (startTimeControl?.value && endTime) {
        this.checkTimeValidation();
      }
    });
  }

  checkTimeValidation() {
    const startTimeControl = this.bookingForm.get('startTime');
    const endTimeControl = this.bookingForm.get('endTime');
    if (
      startTimeControl?.value &&
      endTimeControl?.value &&
      startTimeControl.value > endTimeControl.value
    ) {
      this.bookingForm.get('endTime')?.setErrors({ invalidEndTime: true });
    }
  }

  onSubmit() {
    if (this.bookingForm.invalid) {
      this.bookingForm.markAllAsTouched();
      return;
    }
    console.log(this.bookingForm.value);
    this.Route.navigate(['/dock-management/list']);
  }

  backToList() {
    this.Route.navigate(['/dock-management/list']);
  }
}
