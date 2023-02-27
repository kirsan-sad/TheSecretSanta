import { configureStore } from '@reduxjs/toolkit';
import { setupListeners } from '@reduxjs/toolkit/query';
import { wishAPI } from "../services/wishApi";
import setSearchQuery from "../store/redux/serchTermSlice";
import setWishNumber from "../store/redux/wishNumberSlice";

export const store = configureStore({
  reducer: {
    [wishAPI.reducerPath]: wishAPI.reducer,
    setSearchQuery,
    setWishNumber
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(wishAPI.middleware),
})

setupListeners(store.dispatch)