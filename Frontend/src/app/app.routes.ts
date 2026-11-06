import { Routes } from '@angular/router';
import { DockManagement } from './features/dock-management/dock-management';
import { DockList } from './features/dock-management/Components/dock-list/dock-list';
import { BookingList } from './features/booking-management/Components/booking-list/booking-list';
import { BookingManagement } from './features/booking-management/booking-management';
import { AddEditDock } from './features/dock-management/Components/add-edit-dock/add-edit-dock';
import { AddEditBooking } from './features/booking-management/Components/add-edit-booking/add-edit-booking';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'dock-management',
    pathMatch: 'full',
  },
  {
    path: 'dock-management',
    component: DockManagement,
    children: [
      {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full',
      },
      {
        path: 'list',
        component: DockList,
      },
      {
        path: 'add-dock',
        component: AddEditDock,
      },
       {
        path: 'edit-dock/:id',
        component: AddEditDock,
      },
    ],
  },
  {
    path: 'booking-management',
    component: BookingManagement,
    children: [
      {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full',
      },
      {
        path: 'list',
        component: BookingList,
      },
      {
        path: 'add-booking',
        component: AddEditBooking,
      },
      {
        path: 'edit-booking/:id',
        component: AddEditBooking,
      },
    ],
  },
];
