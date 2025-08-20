import { css } from "styled-components";

export const ThemeColor = {
  Blue: "#2bbed3",
  White: "#ffffff",
  Font1: "40px",
  Font2: "80px",
};

interface Theme {
  First: string;
  Second: string;
}

export const Primary: Theme = {
  First: ThemeColor.Blue,
  Second: ThemeColor.White,
};

export const Secondary: Theme = {
  First: ThemeColor.White,
  Second: ThemeColor.Blue,
};

export const BackgroundPrimary = css`
  background-color: ${({ theme }) => theme.First};
`;
export const BackgroundSecondary = css`
  background-color: ${({ theme }) => theme.Second};
`;

const Border = css`
  border: 1.5px solid;
`;
export const BorderPrimary = css`
  ${Border}
  border-color: ${({ theme }) => theme.First};
`;
export const BorderSecondary = css`
  ${Border}
  border-color: ${({ theme }) => theme.Second};
`;

export const ColorPrimary = css`
  color: ${({ theme }) => theme.Second};
`;
export const ColorSecondary = css`
  color: ${({ theme }) => theme.First};
`;

export const LargeFont = css`
  font-size: 80px;
`;

export const SmallFont = css`
  font-size: 40px;
`;
export const Bold = css`
  font-weight: Bold;
`;

export const Normal = css`
  font-weight: normal;
`;
export const Small = css`
  width: 30px;
  height: 30px;
`;
export const Large = css`
  width: 80px;
  height: 80px;
`;
export const HoverEffect = css`
  transition: opacity 0.3s ease-in-out;

  &:hover {
    opacity: 0.7; /* Adjust opacity for the fade effect */
  }
`;

export const Disable = css`
  &:disabled {
    opacity: 0.5;
    cursor: not-allowed;
  }
`;
