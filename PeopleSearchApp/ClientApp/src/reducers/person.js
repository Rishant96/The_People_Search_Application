import { ACTION_TYPES } from "../actions/person";

const initialState = {
    list: []
} 

export const person = (state=initialState, action) => {
    switch (action.type) {
        case ACTION_TYPES.FETCH_ALL:
            return {
                ...state,
                list: [...action.payload]
            };

        default:
            return state;
    }
}