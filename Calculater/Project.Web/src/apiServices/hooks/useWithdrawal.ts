import { useMutation } from "@tanstack/react-query";
import withdrawalService, { Withdrawal } from "../services/WithdrawalService";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import useResultStore from "../../stateHooks/useResultStore";

export interface WithdrawalQuery {
  amount: number;
}
const useWithdrawal = () => {
  const navigate = useNavigate();
  const { setResultReady } = useResultStore();

  return useMutation<Withdrawal[], Error, WithdrawalQuery>({
    mutationFn: withdrawalService.post,

    onSuccess: (data) => {
      setResultReady(true);
      navigate("/result", { state: data });
    },

    onError: (error: Error) => {
      toast.error(error.message);
    },
  });
};

export default useWithdrawal;
