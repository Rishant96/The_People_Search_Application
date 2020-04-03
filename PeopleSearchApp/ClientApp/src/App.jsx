import React from "react";
import { store } from "./actions/store";
import { Provider } from "react-redux";
import People from "./components/People"

function App() {
    return (
      <Provider store={ store }>
        <People />
      </Provider>
    );
}

export default App;