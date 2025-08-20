import Category from "./Category";
import DivStyled from "./styledElements/DivStyled";

import { Withdrawal } from "../apiServices/services/WithdrawalService";

interface Notes {
  notes: Withdrawal[];
  imageSource: string;
}

function Notes({ notes, imageSource }: Notes) {
  return (
    <DivStyled className="d-flex flex-column justify-content-center align-align-items-center">
      {notes.map((x) => (
        <Category
          key={x.quantity * x.value}
          quantity={x.quantity}
          value={x.value}
          imageSource={imageSource}
          contrast={true}
        />
      ))}
    </DivStyled>
  );
}

export default Notes;
