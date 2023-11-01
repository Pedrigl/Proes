export interface Login {
  username: string;
  password: string;
}

export interface LoginResponse {
  id: number;
  username: string;
  password: string;
  token: string;
  tokenExpiration: number;
  userType: number;
}
