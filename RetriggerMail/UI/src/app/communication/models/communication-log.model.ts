 export interface CommunicationLog {
  id: number;
  claimNumber: string;
  recipientEmail: string;
  recipientMobile: string;
  templateName: string;
  messageBody: string;
  sentDate: string;
  isSuccess: boolean;
}