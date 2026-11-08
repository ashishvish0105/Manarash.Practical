export interface GetBookingModel {
  bookingId: number;
  generatedReferenceNumber: string;
  dockId: number;
  companyName: string;
  licensePlate: string;
  directionId: number;
  statusId: number;
  startTime: Date;
  endTime: Date;
}

export interface CreateBookingRequestModel {
  generatedReferenceNumber: string;
  dockId: number;
  companyName: string;
  licensePlate: string;
  directionId: number;
  statusId: number;
  startTime: Date;
  endTime: Date;
}

export interface EditBookingRequestModel {
  bookingId: number;
  generatedReferenceNumber: string;
  dockId: number;
  companyName: string;
  licensePlate: string;
  directionId: number;
  statusId: number;
  startTime: Date;
  endTime: Date;
}
