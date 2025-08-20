import ButtonActivePrimaryStyled from "./styledElements/ButtonActivePrimaryStyled";
import useAmountStore from "../stateHooks/useAmountStore";
import { ReactNode } from "react";

interface BaseButtonProps {
  children: ReactNode;
  clickHandler: () => void;
}
function BaseButton({ children, clickHandler }: BaseButtonProps) {
  const { amount } = useAmountStore();
  const active = amount !== 0;
  return (
    <ButtonActivePrimaryStyled
      className="p-1 pe-5 ps-5 rounded-pill"
      $active={active}
      disabled={!active}
      onClick={clickHandler}
    >
      {children}
    </ButtonActivePrimaryStyled>
  );
}

export default BaseButton;
