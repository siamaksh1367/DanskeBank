import { styled } from "styled-components";
import {
  Bold,
  ColorPrimary,
  LargeFont,
  SmallFont,
} from "../../styles/ThemeMixin";

const SpanStyled = styled.span<{
  $isLarge?: boolean;
  $isBold?: boolean;
}>`
  ${ColorPrimary};

  ${({ $isBold }) => $isBold && Bold};

  ${({ $isLarge }) => ($isLarge ? LargeFont : SmallFont)};
`;

export default SpanStyled;
