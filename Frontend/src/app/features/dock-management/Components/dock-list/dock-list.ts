import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { ApiReturnResponse } from '../../../../models/apiReturnResponse.model';
import { GetDockModel } from '../../../../models/dockManagement.model';
import { DockManagementServices } from '../../../../services/dock-management.services';
import { ToastService } from '../../../../shared/services/toast.service';
import { DockType } from '../../../../core/enums/dockType.enum';

@Component({
  selector: 'app-dock-list',
  imports: [],
  templateUrl: './dock-list.html',
  styleUrl: './dock-list.scss',
})
export class DockList {
  private Route = inject(Router);
  private dockManagementServices = inject(DockManagementServices);
  private toastService = inject(ToastService);
  docksList = signal<GetDockModel[]>([]);

  ngOnInit(): void {
    this.dockManagementServices.getDocks().subscribe({
      next: (response: ApiReturnResponse<GetDockModel[]>) => {
        this.docksList.set(response.payload);
      },
      error: (err) => {
        console.error('API Error occurred:', err);
        this.toastService.error('Failed to fetch docks. Please try again later.', 'Error');
      },
    });
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

  addDock() {
    this.Route.navigate(['/dock-management/add-dock']);
  }

  editDock(id: number) {
    this.Route.navigate([`/dock-management/edit-dock/${id}`]);
  }

  deleteDock(id: number) {
    if (confirm('Are you sure you want to delete this dock configuration?')) {
      this.dockManagementServices.deleteDock(id).subscribe({
        next: () => {
          this.toastService.success('Dock structure deleted successfully.', 'Success');

          this.docksList.update((docks) => docks.filter((item) => item.dockId !== id));
        },
        error: (err) => {
          console.error(err);
          this.toastService.error('Failed to delete dock mapping asset.', 'Error');
        },
      });
    }
  }

  changeIsActive(dock: GetDockModel) {
    const newStatus = !dock.isActive;
    this.dockManagementServices.changeIsActive(dock.dockId, newStatus).subscribe({
      next: (response: ApiReturnResponse<number>) => {
        if (response.payload > 0) {
          this.toastService.success('Status updated successfully.', 'Success');
        }
        this.docksList.update((docks) =>
          docks.map((item) =>
            item.dockId === dock.dockId ? { ...item, isActive: newStatus } : item,
          ),
        );
      },
      error: (err) => {
        console.error('API Error occurred:', err);
        this.toastService.error('Failed to fetch docks. Please try again later.', 'Error');
      },
    });
  }
}
