import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { ApiReturnResponse } from '../models/apiReturnResponse.model';
import { CreateBookingRequestModel, EditBookingRequestModel, GetBookingModel } from '../models/bookingManagement.model';

@Injectable({
  providedIn: 'root',
})
export class BookingManagementservices {
 private baseUrl = `${environment.BaseUrl}/BookingManagement/`;

  constructor(private http: HttpClient) {}

  getBookings(): Observable<ApiReturnResponse<GetBookingModel[]>> {
    return this.http.get<ApiReturnResponse<GetBookingModel[]>>(this.baseUrl);
  }

  getBooking(id: number): Observable<ApiReturnResponse<GetBookingModel>> {
    return this.http.get<ApiReturnResponse<GetBookingModel>>(`${this.baseUrl}${id}`);
  }

  createBooking(booking: CreateBookingRequestModel): Observable<ApiReturnResponse<number>> {
    return this.http.post<ApiReturnResponse<number>>(this.baseUrl, booking);
  }

  editBooking(id: number, booking: EditBookingRequestModel): Observable<ApiReturnResponse<number>> {
    return this.http.put<ApiReturnResponse<number>>(`${this.baseUrl}${id}`, booking);
  }

  deleteBooking(id: number): Observable<ApiReturnResponse<number>> {
    return this.http.delete<ApiReturnResponse<number>>(`${this.baseUrl}${id}`);
  }
}
