import { PurchaseHistoryItem } from "./purchase-history-item";

export class PurchaseHistory {
  public user_email: string = '';
  public entries: PurchaseHistoryItem[] = [];
}