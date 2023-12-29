export interface NotificationModel {
  id: number;
  userId: number;
  message: string;
  isRead: boolean;
  date: Date;
  type: number;
}
