import { Component, inject, signal } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiReturnResponse } from '../../../../models/apiReturnResponse.model';
import { GetDockModel } from '../../../../models/dockManagement.model';
import { DockManagementServices } from '../../../../services/dock-management.services';
import { ToastService } from '../../../../shared/services/toast.service';
import { DockType } from '../../../../core/enums/dockType.enum';
import { BookingStatusOptions } from '../../../../core/enums/BookingStatus.enum';
import { map } from 'rxjs';
import { BookingManagementservices } from '../../../../services/booking-management.services';
import { required } from '@angular/forms/signals';
import { GetBookingModel } from '../../../../models/bookingManagement.model';

@Component({
  selector: 'app-add-edit-booking',
  imports: [ReactiveFormsModule],
  templateUrl: './add-edit-booking.html',
  styleUrl: './add-edit-booking.scss',
})
export class AddEditBooking {
  dockType = DockType;
  bookingForm!: FormGroup;
  typeOptions = ['Inbound', 'Outbound', 'Both'];
  private fd = inject(FormBuilder);
  private activatedRoute = inject(ActivatedRoute);
  editMode: boolean = false;
  private Route = inject(Router);
  private dockManagementServices = inject(DockManagementServices);
  private bookingManagementservices = inject(BookingManagementservices);
  private toastService = inject(ToastService);
  docksList = signal<GetDockModel[]>([]);
  activeTypeLabel: number = 0;
  bookingStatusOptions = BookingStatusOptions;
  BookingId: number = 0;

  ngOnInit(): void {
    this.getDocks();

    this.bookingForm = this.fd.group({
      generatedReferenceNumber: [`BK-${Date.now()}`, { disabled: true }],
      dockId: [null, [Validators.required]],
      companyName: [null, [Validators.required, Validators.maxLength(150)]],
      licensePlate: [null, [Validators.required, Validators.maxLength(150)]],
      directionId: [''],
      statusId: [null, [Validators.required]],
      startTime: [null, [Validators.required]],
      endTime: [null, [Validators.required]],
    });

    this.activatedRoute.params.subscribe((params) => {
      if (params) {
        this.BookingId = params['id'];
        if (this.BookingId > 0) {
          this.editMode = true;

          this.bookingManagementservices.getBooking(this.BookingId).subscribe({
            next: (response: ApiReturnResponse<GetBookingModel>) => {
              this.bookingForm.patchValue(response.payload);
            },
            error: (err) => {
              console.error('API Error occurred:', err);
              this.toastService.error('Failed to fetch dock. Please try again later.', 'Error');
            },
          });
        }
      }
    });

    this.bookingForm.get('dockId')?.valueChanges.subscribe((dockTypeId: number) => {
      if (dockTypeId > 0) {
        this.activeTypeLabel = dockTypeId;
        this.bookingForm.get('direction')?.setValidators([Validators.required]);
      } else {
        this.bookingForm.get('direction')?.clearValidators();
      }
    });

    this.bookingForm.get('startTime')?.valueChanges.subscribe((startTime) => {
      if (!startTime) {
        return;
      }
      const endTimeControl = this.bookingForm.get('endTime');
      const now = new Date().getTime();
      const startTimeLog = new Date(startTime).getTime();

      if (startTimeLog < now) {
        this.bookingForm.get('startTime')?.setErrors({ invalidStartTime: true });
        return;
      }
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

  onDockChange(dock: Event) {
    const value = dock;
    console.log(dock);
  }

  getDocks() {
    this.dockManagementServices
      .getDocks()
      .pipe(
        map((response: ApiReturnResponse<GetDockModel[]>) => {
          const listData = response.payload || [];
          const activeDocks = listData.filter((dock) => dock.isActive === true);

          return {
            ...response,
            Payload: activeDocks,
          };
        }),
      )
      .subscribe({
        next: (response) => {
          this.docksList.set(response.Payload);
        },
        error: (err) => {
          console.error('API Error occurred:', err);
          this.toastService.error('Failed to fetch docks. Please try again later.', 'Error');
        },
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
    debugger;
    if (this.bookingForm.invalid) {
      this.bookingForm.markAllAsTouched();
      return;
    }

    if (this.editMode && this.BookingId > 0) {
      this.bookingManagementservices.editBooking(this.BookingId, this.bookingForm.value).subscribe({
        next: (response: ApiReturnResponse<number>) => {
          if (response.payload > 0) {
            this.toastService.success('booking successfully updated', 'Success');

            this.Route.navigate(['/booking-management/list']);
          }
        },
        error: (err) => {
          console.error('API Error occurred:', err);

          this.toastService.error('Failed to update booking. Please try again later.', 'Error');
        },
      });
    } else {
      this.bookingManagementservices.createBooking(this.bookingForm.value).subscribe({
        next: (response: ApiReturnResponse<number>) => {
          if (response.payload > 0) {
            this.toastService.success('booking successfully created', 'Success');

            this.Route.navigate(['/booking-management/list']);
          }
        },
        error: (err) => {
          console.error('API Error occurred:', err);

          this.toastService.error('Failed to create booking. Please try again later.', 'Error');
        },
      });
    }
  }

  getDockTypeName(typeId: number): string {
    console.log(typeId);
    switch (typeId) {
      case DockType.Inbound:
        return 'Inbound';

      case DockType.Outbound:
        return 'Outbound';

      case DockType.Both:
        return 'Both';

      default:
        return 'Unknown';
    }
  }

  backToList() {
    this.Route.navigate(['/dock-management/list']);
  }
}
