export interface ApiReturnResponse<T>{
    statusCode: number;
    message: string;
    payload: T;
    error: string;
}
