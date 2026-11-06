import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dock-list',
  imports: [],
  templateUrl: './dock-list.html',
  styleUrl: './dock-list.scss',
})
export class DockList {
  private Route = inject(Router);
  addDock() {
    this.Route.navigate(['/dock-management/add-dock']);
  }
}
