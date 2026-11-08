import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { GetDockModel, CreateDockRequestModel, EditDockRequestModel } from '../models/dockManagement.model';
import { ApiReturnResponse } from '../models/apiReturnResponse.model';

@Injectable({
  providedIn: 'root',
})
export class DockManagementServices {
   private baseUrl = `${environment.BaseUrl}/DockManagement/`;

  constructor(private http: HttpClient) {}

  getDocks(): Observable<ApiReturnResponse<GetDockModel[]>> {
    return this.http.get<ApiReturnResponse<GetDockModel[]>>(this.baseUrl);
  }

  getDock(id: number): Observable<ApiReturnResponse<GetDockModel>> {
    return this.http.get<ApiReturnResponse<GetDockModel>>(`${this.baseUrl}${id}`);
  }

  createDock(dock: CreateDockRequestModel): Observable<ApiReturnResponse<number>> {
    return this.http.post<ApiReturnResponse<number>>(this.baseUrl, dock);
  }

  editDock(id: number, dock: EditDockRequestModel): Observable<ApiReturnResponse<number>> {
    return this.http.put<ApiReturnResponse<number>>(`${this.baseUrl}${id}`, dock);
  }

  changeIsActive(id: number, isActive:boolean): Observable<ApiReturnResponse<number>> {
     const params = new HttpParams().set('isActive', isActive);
    return this.http.put<ApiReturnResponse<number>>(`${this.baseUrl}ChangeIsActive/${id}`,null,{params});

  }

  deleteDock(id: number): Observable<ApiReturnResponse<number>> {
    return this.http.delete<ApiReturnResponse<number>>(`${this.baseUrl}${id}`);
  }
}
