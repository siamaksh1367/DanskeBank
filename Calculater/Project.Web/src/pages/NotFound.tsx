import { useEffect } from "react";
import { Link } from "react-router-dom";

const NotFound = () => {
  useEffect(() => {
    document.title = "Error";
  }, []);
  return (
    <div style={{ textAlign: "center", marginTop: "50px" }}>
      <h1>404 - Not Found</h1>
      <p>The page you're looking for doesn't exist.</p>
      <Link to="/">Go to Home</Link>
    </div>
  );
};

export default NotFound;
