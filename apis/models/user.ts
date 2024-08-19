import { PurchaseHistory } from './purchase-history.ts';

export class User {
  public email: string = '';
  public household_id: string | undefined = undefined;
  public friends: User[] = [];
  public purchase_history: PurchaseHistory | undefined = undefined;
  public diet: string[] = [];
}