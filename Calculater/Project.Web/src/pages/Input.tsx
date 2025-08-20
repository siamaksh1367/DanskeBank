import { useEffect } from "react";
import AmountForm from "../components/AmountForm";

function Input() {
  useEffect(() => {
    document.title = "Input";
  }, []);
  return <AmountForm />;
}

export default Input;
