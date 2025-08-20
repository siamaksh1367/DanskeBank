import { create } from "zustand";

interface ResultStore {
  isResultReady: boolean;
  setResultReady: (ready: boolean) => void;
  toggleResultReady: () => void;
}

const useResultStore = create<ResultStore>((set) => ({
  isResultReady: false,
  setResultReady: (ready) => set({ isResultReady: ready }),
  toggleResultReady: () =>
    set((state) => ({ isResultReady: !state.isResultReady })),
}));

export default useResultStore;
