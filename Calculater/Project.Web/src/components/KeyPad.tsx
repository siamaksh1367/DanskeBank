import RoundButton from "./RoundButton";
import DivKeyPadStyled from "./styledElements/DivKeyPadStyled";
import useAmountStore from "../stateHooks/useAmountStore";
import ImageButton from "./ImageButton";

function KeyPad() {
  const numbers = Array.from({ length: 11 }, (_, i) => i + 1);

  const { addDigit, removeDigit } = useAmountStore();

  const modifyAmount = (number: number) => {
    return () => {
      number !== 10 && number !== 11 && addDigit(number);
      number === 11 && addDigit(0);
      number === 10 && removeDigit();
    };
  };

  return (
    <div className="container d-flex justify-content-center align-items-start mt-5">
      <DivKeyPadStyled className="row m-5">
        {numbers.map((number) => (
          <div className="col-4 p-1 m-0" key={number}>
            <RoundButton clickHandler={modifyAmount(number)}>
              {number === 11 && 0}
              {number !== 11 && number !== 10 && number}
              {number === 10 && <ImageButton />}
            </RoundButton>
          </div>
        ))}
      </DivKeyPadStyled>
    </div>
  );
}

export default KeyPad;
