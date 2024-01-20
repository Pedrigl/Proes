export interface Login {
  username: string;
  password: string;
  userType?: number;
}

export interface LoginResponse {
  id: number;
  username: string;
  token: string;
  tokenExpiration: Date;
  userType: number;
}
