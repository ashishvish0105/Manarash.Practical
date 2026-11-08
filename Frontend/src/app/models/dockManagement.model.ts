export interface GetDockModel {
  dockId: number;
  name: string;
  typeId: number;
  isActive: boolean;
}

export interface CreateDockRequestModel {
  name: string;
  typeId: number;
  isActive: boolean;
}

export interface EditDockRequestModel {
  dockId: number;
  name: string;
  typeId: number;
  isActive: boolean;
}
