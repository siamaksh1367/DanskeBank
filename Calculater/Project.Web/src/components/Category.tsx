import DivStyled from "./styledElements/DivStyled";
import SpanStyled from "./styledElements/SpanStyled";

export interface CategoryProps {
  quantity: number;
  value: number;
  imageSource: string;
  contrast: boolean;
}
function Category({ value, quantity, imageSource }: CategoryProps) {
  return (
    <DivStyled
      $hasBorder={true}
      className="border-1 p-4 d-flex flex-column flex-xxl-row justify-content-around align-items-center"
    >
      <img className="flex-grow-0" src={imageSource}></img>
      <SpanStyled
        className="d-flex flex-column flex-sm-row flex-md-column flex-xl-row justify-content-center align-items-center text-center text-nowrap fs flex-grow-1"
        $isLarge={false}
        $isBold={false}
      >
        <div className="m-0 p-0">{quantity}</div>
        <div className="m-0 p-0">x</div>
        <div className="m-0 p-0">{value}</div>
      </SpanStyled>
    </DivStyled>
  );
}

export default Category;
