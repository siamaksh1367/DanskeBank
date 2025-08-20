import { MouseEventHandler, ReactNode } from "react";
import ButtonRoundPrimaryStyled from "./styledElements/ButtonRoundPrimaryStyled";

interface RoundButtonProps {
  children: ReactNode;
  clickHandler: MouseEventHandler<HTMLButtonElement>;
}
function RoundButton({ children, clickHandler }: RoundButtonProps) {
  return (
    <ButtonRoundPrimaryStyled
      onClick={clickHandler}
      className="rounded-circle m-1"
    >
      {children}
    </ButtonRoundPrimaryStyled>
  );
}

export default RoundButton;
