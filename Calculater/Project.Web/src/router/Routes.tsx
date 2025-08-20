import { createBrowserRouter, Navigate } from "react-router-dom";
import Splash from "../pages/Splash";
import Input from "../pages/Input";
import Result from "../pages/Result";
import NotFound from "../pages/NotFound";

const router = createBrowserRouter([
  {
    path: "*",
    element: <NotFound />, // Handle 404 for undefined routes
  },
  {
    path: "/",
    element: <Navigate to="/splash" />, // Redirect root to /splash
  },
  {
    path: "/splash",
    element: <Splash />,
  },
  {
    path: "/input",
    element: <Input />,
  },
  {
    path: "/result",
    element: <Result />,
  },
]);

export default router;
