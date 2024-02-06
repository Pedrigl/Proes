import { UserType } from "./enums/user.type";

export interface Login {
  username: string;
  password: string;
  userType?: UserType;
}

export interface LoginResponse {
  id: number;
  username: string;
  userId : number;
  token: string;
  tokenExpiration: Date;
  userType: UserType;
}
