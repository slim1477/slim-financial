import { Account } from "./account";

export interface transfer {
  source: Account;
  destination: Account[]
}
