import React, { useState } from 'react';
import { useAddWishMutation } from '../services/wishApi';
import { useSelector } from 'react-redux';
import { useDispatch } from 'react-redux';
import { setWishNumber } from '../store/redux/wishNumberSlice';


const categories = [{id:1, label:"Hobby"}, 
  {id:2, label:"Certificates"}, 
  {id:3, label:"Souveners"}, 
  {id:4, label:"Toys"}, 
  {id:5, label:"Food"},
  {id:6, label:"Gadget"}];

const AddWish = ({setShowForm}) => {
    const [addWish] = useAddWishMutation();
    const [isTextEntered, setIsTextEntered] = useState(false);
    const [isError, setIsError] = useState(false);
    const newNumber = useSelector((state) => state.setWishNumber.curentNumber + 1);
    const dispatch = useDispatch();
    
    const [fields, setFields] = useState({
        category: categories[0],
        isAdult: false,
        date: "",
        wish: "",
        isCompleted: false,
        wishNumber: newNumber
      });

      const handleTextChange = (e) => {
        setFields((prevFields) => ({
          ...prevFields,
          wish: e.target.value,
        }));
      
        setIsTextEntered(true);
      };
    
      const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        const fieldValue = type === "checkbox" ? checked : value;
    
        setFields((prevFields) => ({
          ...prevFields,
          [name]: fieldValue,
        }));
      };

      const handleCancel = () => {
        setFields({
          category: categories[0],
          isAdult: false,
          date: "",
          wish: "",
          isCompleted: false,
        });

        setShowForm(false);
      }
    
      const handleSubmit = async (e) => {
        e.preventDefault();

        if (!isTextEntered) {
          setIsError(true);
          return;
        }

        const body = JSON.stringify(fields);
        await addWish(body).unwrap(); 
        
        dispatch(setWishNumber(newNumber));
        handleCancel();
      };

return (
  <form onSubmit={handleSubmit} className="rounded overflow-hidden shadow-lg mx-auto my-4 bg-white">
    <div className="px-6 py-4">
      <div className="mb-4">
        <label htmlFor="category" className="block text-gray-700 font-bold mb-2">
          Category
        </label>
        <select
          value={fields.category}
          onChange={handleChange}
          id="category"
          name="category"
          className="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline"
        >
          {categories.map((category) => (
            <option key={category.id} value={category.label}>
              {category.label}
            </option>
          ))}
        </select>
      </div>

      <div className="mb-4">
        <label htmlFor="isAdult" className="block text-gray-700 font-bold mb-2">
          Adult 18+
        </label>
        <input
          type="checkbox"
          name="isAdult"
          id="isAdult"
          className="mr-2 leading-tight"
          onChange={handleChange}
          checked={fields.isAdult}
        />
        <label htmlFor="isAdult" className="text-sm">
          Check this box if this wish is for adults only
        </label>
      </div>

      <div className="mb-4">
        <label htmlFor="date" className="block text-gray-700 font-bold mb-2">
          Date
        </label>
        <input
          type="date"
          name="date"
          id="date"
          className="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline"
          value={fields.date}
          onChange={handleChange}
        />
      </div>

      <div className="mb-4">
        <label htmlFor="want" className="block text-gray-700 font-bold mb-2">
          Wish
        </label>
        <textarea
          name="wish"
          id="wish"
          rows="3"
          className="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline"
          defaultValue={fields.wish}
          onChange={handleTextChange}
        ></textarea>
        {isError && !isTextEntered && (
          <p className="text-red-500 text-sm mt-1">
            Please enter a wish before submitting.
          </p>
        )}
      </div>
    </div>
    <div className="flex justify-center mb-4">
        <button
        type="button"
        className="px-4 py-2 text-sm font-medium text-white bg-gray-700 rounded-md hover:bg-gray-600 focus:outline-none focus:ring-2 focus:ring-gray-500 focus:ring-offset-2"
        onClick={handleCancel}
        >
        Cancel
        </button>
        <button
        type="submit"
        className="ml-3 px-4 py-2 text-sm font-bold text-white bg-emerald-500 rounded-md hover:bg-emerald-700 focus:outline-none focus:ring-2 focus:ring-green-500 focus:ring-offset-2"
        >
        Add
        </button>
    </div>
  </form>)
}

export default AddWish;