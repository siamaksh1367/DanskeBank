import { styled } from "styled-components";
import {
  BackgroundPrimary,
  BackgroundSecondary,
  Bold,
  BorderPrimary,
  BorderSecondary,
  ColorPrimary,
  Disable,
  HoverEffect,
} from "../../styles/ThemeMixin";
import { SmallFont } from "../../styles/ThemeMixin";
import { ColorSecondary } from "../../styles/ThemeMixin";

const ButtonActivePrimaryStyled = styled.button<{ $active?: boolean }>`
  ${({ $active }) => ($active ? BackgroundSecondary : BackgroundPrimary)};
  ${({ $active }) => ($active ? ColorSecondary : ColorPrimary)};
  ${({ $active }) => ($active ? BorderPrimary : BorderSecondary)};
  ${SmallFont}
  ${({ $active }) => $active && HoverEffect};
  ${Bold}
  ${Disable}
`;

export default ButtonActivePrimaryStyled;
