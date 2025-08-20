import DivStyled from "./styledElements/DivStyled";

function Loading() {
  return (
    <DivStyled
      className="d-flex justify-content-center align-items-center position-absolute top-0 start-0 w-100 h-100 "
      style={{ position: "absolute", top: 0, left: 0 }}
    >
      <div className="d-flex flex-column justify-content-center align-items-center">
        <div className="spinner-border" role="status" />
        <span className="sr-only">Loading...</span>
      </div>
    </DivStyled>
  );
}

export default Loading;
