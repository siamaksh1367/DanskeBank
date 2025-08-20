import { useEffect } from "react";
import RoundButton from "../components/RoundButton";
import SpanStyledWithWrap from "../components/styledElements/SpanStyledWithWrap";
import ValuePresenter from "../components/ValuePresenter";
import Withdrawals from "../components/Withdrawals";
import useResultStore from "./../stateHooks/useResultStore";
import { useLocation, useNavigate } from "react-router-dom";
import ImageButton from "../components/ImageButton";
import { Withdrawal } from "../apiServices/services/WithdrawalService";
import useAmountStore from "../stateHooks/useAmountStore";

function Result() {
  const { isResultReady, setResultReady } = useResultStore();
  const navigate = useNavigate();
  const location = useLocation();
  const { amount } = useAmountStore();
  const state = location.state as Withdrawal[];

  const goToInput = () => {
    navigate("/input");
  };

  useEffect(() => {
    document.title = "Result";
    return () => {
      setResultReady(false);
    };
  }, [amount]);

  if (!isResultReady && !state) {
    return (
      <div className="container">
        <div className="row">
          <div className="col text-center">
            <SpanStyledWithWrap
              $isLarge={false}
              $isBold={true}
              className="m-5 text-center"
            >
              The content should be generated first. Please visit input page
            </SpanStyledWithWrap>
            <RoundButton clickHandler={goToInput}>
              <ImageButton />
            </RoundButton>
          </div>
        </div>
      </div>
    );
  }
  return (
    <div className="container mt-5 pt-5 ">
      <div className="row mt-5 position-relative">
        <div className="col text-center">
          <SpanStyledWithWrap
            $isLarge={false}
            $isBold={true}
            className=" text-center"
          >
            Depositing
          </SpanStyledWithWrap>
        </div>
        <div className="position-absolute top-0 start-0 ">
          <RoundButton clickHandler={goToInput}>
            <ImageButton />
          </RoundButton>
        </div>
      </div>
      <div className="row">
        <div className="col text-center">
          <ValuePresenter amount={amount} />
        </div>
      </div>
      <div className="row">
        <div className="col text-center">
          <Withdrawals Withdrawals={state} />
        </div>
      </div>
      <div className="row">
        <div className="col">
          <SpanStyledWithWrap
            $isLarge={false}
            $isBold={true}
            className="d-flex flex-column justify-content-center m-5 text-center"
          >
            <span>Thank you for using</span>
            <span>Project ATM</span>
          </SpanStyledWithWrap>
        </div>
      </div>
    </div>
  );
}

export default Result;
