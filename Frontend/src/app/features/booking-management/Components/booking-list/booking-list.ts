import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking-list',
  imports: [],
  templateUrl: './booking-list.html',
  styleUrl: './booking-list.scss',
})
export class BookingList {
  private Route = inject(Router);

  addBooking() {
    this.Route.navigate(['/booking-management/add-booking']);
  }
}
