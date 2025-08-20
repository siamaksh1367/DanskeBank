import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import SpanStyledWithWrap from "../components/styledElements/SpanStyledWithWrap";

function Splash() {
  const navigate = useNavigate();

  useEffect(() => {
    document.title = "Welcome";
    const timer = setTimeout(() => {
      navigate("/input");
    }, 3000);

    return () => clearTimeout(timer);
  }, [navigate]);

  return (
    <div className="vh-100 vw-100 flex-column d-flex justify-content-center align-items-center">
      <SpanStyledWithWrap $isLarge={true}>Project</SpanStyledWithWrap>
      <SpanStyledWithWrap $isLarge={true}>ATM</SpanStyledWithWrap>
    </div>
  );
}

export default Splash;
