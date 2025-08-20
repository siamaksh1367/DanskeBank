import APIClient from "../ApiClient";
import { WithdrawalQuery } from "../hooks/useWithdrawal";

export interface Withdrawal {
  value: number;
  quantity: number;
  location: number;
}

export default new APIClient<WithdrawalQuery, Withdrawal[]>("/withdrawal");
