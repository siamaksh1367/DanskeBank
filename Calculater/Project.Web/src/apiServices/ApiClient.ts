import axios, { AxiosInstance, AxiosResponse } from "axios";

class APIClient<Input, Output> {
  endpoint: string;
  axiosInstance: AxiosInstance;
  constructor(endpoint: string) {
    this.endpoint = endpoint;
    this.axiosInstance = axios.create({
      baseURL: import.meta.env.VITE_API_URL,
      timeout: 5000,
    });
  }

  post = async (data: Input): Promise<Output> => {
    const response: AxiosResponse<Output> = await this.axiosInstance.post(
      this.endpoint,
      data,
      {
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
    return response.data;
  };
}

export default APIClient;
