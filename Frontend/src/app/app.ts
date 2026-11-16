import { Component, signal } from '@angular/core';
import { Layout } from './shared/layout/layout';
import { LoaderService } from './shared/services/loader.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [Layout,AsyncPipe],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('DocManagementSystem');
  constructor(public loaderService: LoaderService) {}
}
