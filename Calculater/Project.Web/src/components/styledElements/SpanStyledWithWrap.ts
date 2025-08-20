import { styled } from "styled-components";
import SpanStyled from "./SpanStyled";

const SpanStyledWithWrap = styled(SpanStyled)<{
  $isLarge?: boolean;
  $isBold?: boolean;
}>`
  display: inline-block;

  @media (max-width: 576px) {
    display: block;
    width: 100%;
    word-break: break-word;
    overflow-wrap: break-word;
  }
`;

export default SpanStyledWithWrap;
