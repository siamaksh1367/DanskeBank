import SpanStyledWithWrap from "./styledElements/SpanStyledWithWrap";

interface ValuePresenterProps {
  amount: number;
}

function ValuePresenter({ amount }: ValuePresenterProps) {
  return (
    <SpanStyledWithWrap
      className="text-center mt-5"
      $isLarge={true}
      $isBold={true}
    >
      £ {amount}
    </SpanStyledWithWrap>
  );
}

export default ValuePresenter;
