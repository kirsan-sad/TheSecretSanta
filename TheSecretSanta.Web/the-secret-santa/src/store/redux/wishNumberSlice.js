import { createSlice } from '@reduxjs/toolkit';

const wishNumberSlice = createSlice({
  name: 'wishNumber',
  initialState: {
    curentNumber: 3, //According to the wishes generated in advance on the server for demonstration
  },
  reducers: {
    setWishNumber: (state, action) => {
      state.curentNumber = action.payload;
    },
  },
});

export const { setWishNumber } = wishNumberSlice.actions;
export default wishNumberSlice.reducer;