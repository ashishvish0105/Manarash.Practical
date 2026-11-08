import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DockManagementServices } from '../../../../services/dock-management.services';
import { GetDockModel } from '../../../../models/dockManagement.model';
import { ToastService } from '../../../../shared/services/toast.service';
import { ApiReturnResponse } from '../../../../models/apiReturnResponse.model';
import { typeOptions } from '../../../../core/enums/dockType.enum';

@Component({
  selector: 'app-add-edit-dock',
  imports: [ReactiveFormsModule],
  templateUrl: './add-edit-dock.html',
  styleUrl: './add-edit-dock.scss',
})
export class AddEditDock implements OnInit {
  dockForm!: FormGroup;
  typeOptions = typeOptions;
  dockId: number = 0;
  private fd = inject(FormBuilder);
  private activatedRoute = inject(ActivatedRoute);
  editMode: boolean = false;
  private Route = inject(Router);
  private dockManagementServices = inject(DockManagementServices);
  private toastService = inject(ToastService);

  ngOnInit(): void {
    this.dockForm = this.fd.group({
      name: [null, [Validators.required, Validators.maxLength(100)]],
      typeId: [null, [Validators.required]],
      isActive: [true],
    });

    this.activatedRoute.params.subscribe((params) => {
      this.dockId = params['id'];
      if (this.dockId) {
        this.editMode = true;
        this.dockManagementServices.getDock(this.dockId).subscribe({
          next: (response: ApiReturnResponse<GetDockModel>) => {
            this.dockForm.patchValue(response.payload);
          },
          error: (err) => {
            console.error('API Error occurred:', err);
            this.toastService.error('Failed to fetch dock. Please try again later.', 'Error');
          },
        });
      }
    });
  }

  onSubmit() {
    if (this.dockForm.invalid) {
      this.dockForm.markAllAsTouched();
      return;
    }

    if (this.editMode && this.dockId > 0) {
      this.dockManagementServices.editDock(this.dockId, this.dockForm.value).subscribe({
        next: (response: ApiReturnResponse<number>) => {
          if (response.payload > 0) {
            this.toastService.success('Dock successfully updated', 'Success');

            this.Route.navigate(['/dock-management/list']);
          }
        },
        error: (err) => {
          console.error('API Error occurred:', err);

          this.toastService.error('Failed to update dock. Please try again later.', 'Error');
        },
      });
    } else {
      this.dockManagementServices.createDock(this.dockForm.value).subscribe({
        next: (response: ApiReturnResponse<number>) => {
          if (response.payload > 0) {
            this.toastService.success('Dock successfully created', 'Success');

            this.Route.navigate(['/dock-management/list']);
          }
        },
        error: (err) => {
          console.error('API Error occurred:', err);

          this.toastService.error('Failed to create dock. Please try again later.', 'Error');
        },
      });
    }
  }

  backToList() {
    this.Route.navigate(['/dock-management/list']);
  }
}
