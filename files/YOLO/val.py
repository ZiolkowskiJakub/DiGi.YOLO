import argparse
import os
from ultralytics import YOLO

# Validates a YOLO detector on one split of a dataset and prints its box mAP.
#
# Output contract read by DiGi.YOLO Modify.Validate (one value per line, invariant formatting):
#   mAP50: <float>
#   mAP50-95: <float>
# Exit code 0 only when both values were printed.


def main():
    parser = argparse.ArgumentParser(description="YOLO Validation Script")
    parser.add_argument("--model", type=str, required=True, help="Path to the weights file to validate")
    parser.add_argument("--data", type=str, default="conf.yaml", help="Path to the dataset configuration file (conf.yaml)")
    parser.add_argument("--split", type=str, default="test", choices=["val", "test"], help="Dataset split to validate on")
    parser.add_argument("--imgsz", type=int, default=640, help="Square validation image size")
    parser.add_argument("--batch", type=int, default=16, help="Validation batch size")
    parser.add_argument("--conf", type=float, default=None, help="Confidence threshold; the ultralytics validation default when omitted")
    parser.add_argument("--device", type=str, default=None, help="Device, e.g. 0 or cpu")

    args = parser.parse_args()

    if not os.path.isfile(args.model):
        print(f"Could not find model: {args.model}")
        exit(1)

    if not args.data or not os.path.isfile(args.data):
        print(f"Could not find data: {args.data}")
        exit(1)

    valArguments = {
        "data": os.path.abspath(args.data),
        "split": args.split,
        "imgsz": args.imgsz,
        "batch": args.batch,
        "plots": False,
    }

    if args.conf is not None:
        valArguments["conf"] = args.conf

    if args.device:
        valArguments["device"] = args.device

    model = YOLO(os.path.abspath(args.model))
    metrics = model.val(**valArguments)

    # repr of a float is culture-free and round-trips
    print(f"mAP50: {repr(float(metrics.box.map50))}")
    print(f"mAP50-95: {repr(float(metrics.box.map))}")


if __name__ == "__main__":
    main()
