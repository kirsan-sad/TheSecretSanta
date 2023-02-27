import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

const API_URL = "http://localhost:7256";
const apiKey = "6A363E9E-A6B8-45E0-A100-3ED7F362FE53";

export const wishAPI = createApi({
  reducerPath: "wishAPI",
  tagTypes:['Wish'],
  baseQuery: fetchBaseQuery({
      baseUrl: API_URL,
      prepareHeaders: (headers) => {
        headers.set('Content-Type', 'application/json');

        if (apiKey) {
          headers.set('X-API-Key', apiKey)
        }
        return headers
      }}),
  endpoints: (builder) => ({
    getWishs: builder.query({
        query: () => ({
          url: `/wish/`,
          params: {
            take: 10
          }
        }),
        transformResponse: (response) => response.data,
        providesTags: result => ['Wish']
    }),
    getWishsById: builder.query({
        query: (id) => ({
          url: `/wish/${id}`,
        }),
        providesTags: result => ['Wish']
    }),
    searchWish: builder.query({
        query: (searchTerm) => ({
          url: `/wish`,
          params: {
            searchTerm: searchTerm,
            take: 20
          }
        }),
        transformResponse: (response) => response.data,
        providesTags: result => ['Wish']
    }),
    addWish: builder.mutation({
      query: (body) => ({
        url: "/wish",
        method: "POST",
        body,
      }),
      invalidatesTags: result => ['Wish']
    }),
    updateWish: builder.mutation({
      query: (args) => ({
        url: `/wish/${args.id}`,
        method: "PUT",
        body: args.body,
      }),
      invalidatesTags: result => ['Wish']
    }),
    deleteWish: builder.mutation({
      query: (id) => ({
        url: `/wish/${id}`,
        method: "DELETE",
      }),
      invalidatesTags: result => ['Wish']
    }),
  }),
});

export const { useGetWishsQuery, 
    useUpdateWishMutation, 
    useAddWishMutation, 
    useDeleteWishMutation, 
    useSearchWishQuery, 
    useGetWishsByIdQuery } = wishAPI;