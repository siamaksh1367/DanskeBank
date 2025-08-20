import { createGlobalStyle } from "styled-components";
import { BackgroundPrimary, ColorSecondary } from "./ThemeMixin";

const GlobalStyle = createGlobalStyle`
    body {
    ${ColorSecondary}
    ${BackgroundPrimary}
        font-family: "Helvetica Neue",Helvetica,Arial,Sans-serif;
    }
`;
export default GlobalStyle;
