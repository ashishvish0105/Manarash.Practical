import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-edit-dock',
  imports: [ReactiveFormsModule],
  templateUrl: './add-edit-dock.html',
  styleUrl: './add-edit-dock.scss',
})
export class AddEditDock implements OnInit {
  dockForm!: FormGroup;
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

    this.dockForm = this.fd.group({
      name: [null, [Validators.required, Validators.maxLength(100)]],
      type: [null, [Validators.required]],
      isActive: [true],
    });
  }

  onSubmit() {
    if (this.dockForm.invalid) {
      this.dockForm.markAllAsTouched();
      return;
    }
    console.log(this.dockForm.value);
        this.Route.navigate(['/dock-management/list']);
  }

  backToList() {
    this.Route.navigate(['/dock-management/list']);
  }
}
