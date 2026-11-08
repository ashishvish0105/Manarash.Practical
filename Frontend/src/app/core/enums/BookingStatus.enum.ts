export enum BookingStatus {
  Booked = 1,
  CheckedIn = 2,
  AtDock = 3,
  Departed = 4,
  Cancelled = 5,
}

export const BookingStatusOptions = [
  { label: 'Booked', value: BookingStatus.Booked },
  { label: 'CheckedIn', value: BookingStatus.CheckedIn },
  { label: 'AtDock', value: BookingStatus.CheckedIn },
  { label: 'Departed', value: BookingStatus.Departed },
  { label: 'Cancelled', value: BookingStatus.Cancelled }
];
