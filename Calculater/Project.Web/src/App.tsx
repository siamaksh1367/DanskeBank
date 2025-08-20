import { ThemeProvider } from "styled-components";
import GlobalStyle from "./styles/GlobalStyle";
import { Primary } from "./styles/ThemeMixin";
import { toast, ToastContainer } from "react-toastify";
import { RouterProvider } from "react-router-dom";
import router from "./router/Routes";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ErrorBoundary } from "react-error-boundary";
import NotFound from "./pages/NotFound";

const client = new QueryClient({});
function App() {
  return (
    <ErrorBoundary
      FallbackComponent={NotFound}
      onError={(error) => toast.error(error.message)}
    >
      <QueryClientProvider client={client}>
        <ThemeProvider theme={Primary}>
          <GlobalStyle />
          <ToastContainer />
          <RouterProvider router={router} />
        </ThemeProvider>
      </QueryClientProvider>
    </ErrorBoundary>
  );
}

export default App;
