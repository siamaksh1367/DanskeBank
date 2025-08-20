import DivStyled from "../components/styledElements/DivStyled";
import Notes from "./../components/Notes";
import { Withdrawal } from "./../apiServices/services/WithdrawalService";
import NoteImage from "./../assets/500-bill.png";
import CoinImage from "./../assets/coin.png";
interface WithdrawalsProps {
  Withdrawals: Withdrawal[];
}
function Withdrawals({ Withdrawals }: WithdrawalsProps) {
  return (
    <DivStyled className="container">
      <div className="row g-4 g-md-4 ">
        {
          <div className="col-12 col-md-4">
            {
              <Notes
                notes={Withdrawals.filter((x) => x.location === 1)}
                imageSource={NoteImage}
              />
            }
          </div>
        }
        {
          <div className="col-12 col-md-4">
            {
              <Notes
                notes={Withdrawals.filter((x) => x.location === 2)}
                imageSource={CoinImage}
              />
            }
          </div>
        }
        {
          <div className="col-12 col-md-4">
            {
              <Notes
                notes={Withdrawals.filter((x) => x.location === 3)}
                imageSource={CoinImage}
              />
            }
          </div>
        }
      </div>
    </DivStyled>
  );
}

export default Withdrawals;
