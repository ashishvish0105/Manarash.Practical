import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {
  private loaderSubject = new BehaviorSubject<boolean>(false);
  // I created a BehaviorSubject to manage the loader state.
  // Its initial value is false.
  // It means the loader is hidden by default.
  // BehaviorSubject stores the latest value and sends it to subscribers.

  loader$ = this.loaderSubject.asObservable();

  show() {
    this.loaderSubject.next(true);
  }

  hide() {
    this.loaderSubject.next(false);
  }
}
