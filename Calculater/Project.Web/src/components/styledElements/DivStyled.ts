import { styled } from "styled-components";
import { BackgroundPrimary, ColorPrimary } from "../../styles/ThemeMixin";
import { BorderSecondary } from "./../../styles/ThemeMixin";

const DivStyled = styled.div<{ $hasBorder?: boolean }>`
  ${BackgroundPrimary}
  ${ColorPrimary}
  ${({ $hasBorder }) => $hasBorder && BorderSecondary}
`;

export default DivStyled;
