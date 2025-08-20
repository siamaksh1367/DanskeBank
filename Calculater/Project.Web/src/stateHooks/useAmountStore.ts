import { create } from "zustand";
import { toast } from "react-toastify";

const MAX_SAFE_INTEGER = Number.MAX_SAFE_INTEGER;

interface AmountStore {
  amount: number;
  addDigit: (digit: number) => void;
  removeDigit: () => void;
}

const useAmountStore = create<AmountStore>((set) => ({
  amount: 0,

  addDigit: (digit) =>
    set((state) => {
      const newAmount = state.amount * 10 + digit;

      if (newAmount <= MAX_SAFE_INTEGER) {
        return { amount: newAmount };
      } else {
        toast.error("Maximum number size exceeded!");
        return state;
      }
    }),

  removeDigit: () =>
    set((state) => ({
      amount: Math.floor(state.amount / 10),
    })),
}));

export default useAmountStore;
