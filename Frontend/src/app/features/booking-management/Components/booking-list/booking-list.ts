import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { ApiReturnResponse } from '../../../../models/apiReturnResponse.model';
import { GetBookingModel } from '../../../../models/bookingManagement.model';
import { ToastService } from '../../../../shared/services/toast.service';
import { BookingManagementservices } from '../../../../services/booking-management.services';
import { DockManagementServices } from '../../../../services/dock-management.services';
import { GetDockModel } from '../../../../models/dockManagement.model';
import { DockType } from '../../../../core/enums/dockType.enum';
import { BookingStatus } from '../../../../core/enums/BookingStatus.enum';

@Component({
  selector: 'app-booking-list',
  imports: [],
  templateUrl: './booking-list.html',
  styleUrl: './booking-list.scss',
})
export class BookingList {
  private Route = inject(Router);
  private bookingManagementServices = inject(BookingManagementservices);
  private dockManagementServices = inject(DockManagementServices);
  private toastService = inject(ToastService);
  docksList = signal<GetDockModel[]>([]);
  bookingsList = signal<GetBookingModel[]>([]);

  ngOnInit(): void {
    this.bookingManagementServices.getBookings().subscribe({
      next: (response: ApiReturnResponse<GetBookingModel[]>) => {
        // Map data safely based on your payload key structure (Payload or data)
        this.bookingsList.set(response.payload);
      },
      error: (err) => {
        console.error('API Error occurred:', err);
        this.toastService.error('Failed to fetch bookings. Please try again later.', 'Error');
      },
    });
  }

  getDocks() {
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

  addBooking() {
    this.Route.navigate(['/booking-management/add-booking']);
  }

  editBooking(id: number) {
    this.Route.navigate([`/booking-management/edit-booking/${id}`]);
  }

  deleteBooking(id: number) {
    if (confirm('Are you sure you want to delete this booking configuration?')) {
      this.bookingManagementServices.deleteBooking(id).subscribe({
        next: () => {
          this.toastService.success('Booking deleted successfully.', 'Success');
          // Instantly filter out item locally to avoid a full API refresh
          this.bookingsList.update((bookings) => bookings.filter((item) => item.bookingId !== id));
        },
        error: (err) => {
          console.error(err);
          this.toastService.error('Failed to delete booking structure.', 'Error');
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

      default:
        return 'Unknown';
    }
  }

  getBookingStatusName(statusId: number): string {
    switch (statusId) {
      case BookingStatus.Booked:
        return 'Booked';

      case BookingStatus.CheckedIn:
        return 'Checked In';

      case BookingStatus.AtDock:
        return 'At Dock';

      case BookingStatus.Departed:
        return 'Departed';

      case BookingStatus.Cancelled:
        return 'Cancelled';

      default:
        return 'Unknown';
    }
  }
}
